const mongodb = require("../data/database");
const ObjectId = require("mongodb").ObjectId;

const getAll = async (req, res) => {
  //#swagger.tags=['Trainer']
  try {
    const db = mongodb.getDb().db();
    const lists = await db.collection("trainers").find().toArray();
    res.setHeader("Content-Type", "application/json");
    res.status(200).json(lists);
  } catch (err) {
    res.status(400).json({ message: err.message });
  }
};

const getSingle = async (req, res) => {
  //#swagger.tags=['Trainer']
  if (!ObjectId.isValid(req.params.id)) {
    res.status(400).json("Must use a valid Trainer ID to find the trainer");
  }
  const trainerId = new ObjectId(req.params.id);
  try {
    const result = await mongodb.getDb().db().collection("trainers").find({ _id: trainerId }).toArray();
    res.setHeader("Content-Type", "application/json");
    res.status(200).json(result[0]);
  } catch (err) {
    res.status(400).json({ message: err.message });
  }
};

const createTrainer = async (req, res) => {
  //#swagger.tags=['Trainer']
  const pkmnTrainer = {
    trainer: req.body.trainer,
    badges: req.body.badges,
    age: req.body.age,
    favoritePkmn: req.body.favoritePkmn

  };
  const response = await mongodb.getDb().db().collection("trainers").insertOne(pkmnTrainer);

  if (response.acknowledged) {
    res.status(204).send();
  } else {
    res.status(500).json(response.error) || "Some error occurred while cataloging the new trainer";
  }
};

const updateTrainer = async (req, res) => {
  //#swagger.tags=['Trainer']
  if (!ObjectId.isValid(req.params.id)) {
    res.status(400).json("Must use a valid Trainer ID to update the trainer's info");
  }
  const trainerId = new ObjectId(req.params.id);
  const pkmnTrainer = {
    trainer: req.body.trainer,
    badges: req.body.badges,
    age: req.body.age,
    favoritePkmn: req.body.favoritePkmn
  };
  const response = await mongodb
    .getDb()
    .db()
    .collection("trainers")
    .replaceOne({ _id: trainerId }, pkmnTrainer);

  if (response.modifiedCount > 0) {
    res.status(204).send();
  } else {
    res.status(500).json(response.error) ||
      "Some error occurred while updating the trainer's information.";
  }
};

const deleteTrainer = async (req, res) => {
  //#swagger.tags=['Trainer']
  if (!ObjectId.isValid(req.params.id)) {
    res.status(400).json("Must use a valid Train ID to delete the trainer's info");
  }
  const trainerId = new ObjectId(req.params.id);
  const response = await mongodb
    .getDb()
    .db()
    .collection("trainers")
    .deleteOne({ _id: trainerId }, true);

  if (response.deleteCount > 0) {
    res.status(204).send();
  } else {
    res.status(500).json(response.error) || "Some error occurred while deleting the trainer";
  }
};

module.exports = { getAll, getSingle, createTrainer, updateTrainer, deleteTrainer };
