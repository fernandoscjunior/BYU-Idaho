const dotenv = require('dotenv');
dotenv.config();
const MongoClient = require('mongodb').MongoClient;
let database;

//Returns that the Database is connect, if not, connects to it using .env MONGODB_URL
const initDb = (callback) => {
    if (database){
        console.log("Database is initialized");
        return callback(null, database);
    } 
    MongoClient.connect(process.env.MONGODB_URL)
        .then((client) => {
            database = client;
            callback(null, database);
        })
        .catch((err) => {
            callback(err);
        });
};

//Verifies if db is initialized
const getDatabase = () => {
    if (!database) {
        throw Error("Database not initialized");
    }
    return database;
};

module.exports = { initDb, getDatabase };