// backend/test-mongoose-model.js
require('dotenv').config();
const mongoose = require('mongoose');

const uri = process.env.MONGODB_URI;

mongoose.connect(uri, {
    useNewUrlParser: true,
    useUnifiedTopology: true,
})
.then(() => {
    console.log('Connected to MongoDB via Mongoose!');

    // Define a simple schema
    const testSchema = new mongoose.Schema({
        name: String
    });

    // Create a model
    const TestModel = mongoose.model('Test', testSchema);

    // Create a document
    const testDoc = new TestModel({ name: 'Test Document' });

    // Save the document
    testDoc.save()
        .then(() => {
            console.log('Document saved successfully!');

            // Find all documents
            TestModel.find({})
                .then(docs => {
                    console.log('Found documents:', docs);
                    mongoose.connection.close();
                })
                .catch(err => {
                    console.error('Error finding documents:', err);
                    mongoose.connection.close();
                });
    })
    .catch(err => {
        console.error('Error saving document:', err);
        mongoose.connection.close();
    });