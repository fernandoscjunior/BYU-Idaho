const router = require('express').Router();

router.use("/", require("./swagger"))

router.get('/', (req, res) => {
    //#swagger.tags=['Hello World']
    res.send("Hello world!");
});

router.use('/contacts', require('./users'));

module.exports = router;