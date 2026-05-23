const express = require('express');
const router = express.Router();
const pkmnController = require('../controllers/pkmn');
const validation = require('../middleware/validate');
const auth = require("../middleware/authenticate");

router.get('/', pkmnController.getAll);
router.get("/:id", pkmnController.getSingle);
router.post("/", auth.isAuthenticated,validation.savePkmn, pkmnController.createPkmn);
router.put("/:id", auth.isAuthenticated,validation.savePkmn, pkmnController.updatePkmn);
router.delete("/:id", auth.isAuthenticated, pkmnController.deletePkmn);

module.exports = router;