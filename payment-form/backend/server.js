const express = require('express');
const bodyParser = require('body-parser');
const stripe = require('stripe')('secter-key-here');

const app = express();
const PORT = process.env.PORT || 3000;

app.use(bodyParser.json());
app.use(express.static('public'));

app.post('/subscribe', async (req, res) => {
    try {
        const { name, email, token } = req.body;

        const subscriber = await stripe.customers.create({
            name: name,
            email: email,
            source: token 
        });

        const subscription = await stripe.subscriptions.create({
            subscriber: subscriber.id,
            items: [{ plan: 'civilwars-plus' }]
        });

        res.json({ success: true });
    } catch(error) {
        console.log('Error: ', error);
        res.json({ success: false, error: error.message });
    }
});

app.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
});