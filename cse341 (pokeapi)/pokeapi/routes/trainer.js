const express = require('express');
const router = express.Router();
const trainerController = require('../controllers/trainer');
const validation = require('../middleware/validate');
const auth = require("../middleware/authenticate");


router.get('/', trainerController.getAll);
router.get("/:id", trainerController.getSingle);
router.post("/", auth.isAuthenticated, validation.saveTrainer, trainerController.createTrainer);
router.put("/:id", auth.isAuthenticated, validation.saveTrainer, trainerController.updateTrainer);
router.delete("/:id", auth.isAuthenticated, trainerController.deleteTrainer);

module.exports = router;