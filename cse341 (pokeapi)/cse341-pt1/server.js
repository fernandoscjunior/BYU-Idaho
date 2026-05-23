const express = require('express');
const app = express();
const mongodb = require('./data/database');
const bodyParser = require("body-parser");
const port = process.env.PORT || 3000;
const swaggerUi = require("swagger-ui-express");
const swaggerDocument = require("./swagger.json");

app.use("/api-docs", swaggerUi.serve, swaggerUi.setup(swaggerDocument));

app.use(bodyParser.json());

app.use((req, res, next) => {
    res.setHeader("Access-Control-Allow-Origin", "*");
    res.setHeader("Access-Control-Allow-Headers",
        "Origin, X-Requested-With, Content-Type, Accept, Z-key"
    );
    res.setHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
    next();
});

app.use('/', require('./routes'));

mongodb.initDb((err) => {
    if(err){
        console.log(err);
    } else {
        app.listen(port, () => {console.log(`Database is running and node is running on port ${port}`)});
    }
});