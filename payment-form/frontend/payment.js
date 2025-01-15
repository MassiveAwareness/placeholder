// To-Do: Activate Stripe and paste my link here!
const stripe = Stripe('secret-key-here');
const elements = stripe.elements();
const cardElement = elements.create('card');

cardElement.mount('#card-element');

document.getElementById('subscriptionForm').addEventListener('submit', async function (event) {
    event.preventDefault();

    const { token, error } = await stripe.createToken(cardElement);

    if(error) alert(error.message);
    else {
        fetch('/subscribe', {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                name: document.getElementById('name').value,
                email: document.getElementById('email').value,
                token: token.id
            })
        })
            .then(response => response.json())
            .then(data => {
                if(data.success) {
                    alert('Subscription successful!');
                } else {
                    alert('Subscription failed. Please try again!');
                }
            })
            .catch(error => {
                console.error('Error: ', error.message);
                alert('An error occured. Please try again!');
            });
    }
});