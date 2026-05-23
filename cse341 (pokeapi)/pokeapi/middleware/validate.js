const validator = require("../helpers/validate");

const savePkmn = (req, res, next) => {
    const validationRule = {
        pokemon: 'required|string',
        types: 'required|string',
        evolution: 'required|string',
        level: 'required|string',
        nature: 'required|string',
        gender: 'required|string',
        category: 'required|string'
    };
    validator(req.body, validationRule, {}, (err, status) => {
        if (!status) {
            res.status(412).send({
                success: false,
                message: 'Validation Failed',
                data: err
            });
        } else {
            next();
        }
    });
};

const saveTrainer = (req, res, next) => {
  const validationRule = {
    trainer: "required|string",
    badges: "required|string",
    age: "required|string",
    favoritePkmn: "string"
  };
  validator(req.body, validationRule, {}, (err, status) => {
    if (!status) {
      res.status(412).send({
        success: false,
        message: "Validation Failed",
        data: err
      });
    } else {
      next();
    }
  });
};


module.exports = {
    savePkmn,
    saveTrainer
}