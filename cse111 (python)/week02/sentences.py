from random import choice

def get_determiner(quantity):
    if quantity == 1:
        words = ["a", "one", "the"]
    else:
        words = ["some", "many", "the"]
    
    word = choice(words)
    return word

def get_noun(quantity):
    if quantity == 1:
        words = ["bird", "boy", "car", "cat", "child", "dog", "girl", "man", "rabbit", "woman"]
    else:
        words = ["birds", "boys", "cars", "cats", "children", "dogs", "girls", "men", "rabbits", "women"]

    word = choice(words)
    return word

def get_verb(quantity, tense):
  
    if tense == "past":
        words = ["drank", "ate", "grew", "laughed", "thought", "ran", "slept", "talked", "walked", "wrote"]
    elif tense == "present" and quantity == 1:
        words = ["drinks", "eats", "grows", "laughs", "thinks", "runs", "sleeps", "talks", "walks", "writes"]
    elif tense == "present" and quantity != 1:
        words = ["drink", "eat", "grow", "laugh", "think", "run", "sleep", "talk", "walk", "write"]
    elif tense == "future":
        words = ["will drink", "will eat", "will grow", "will laugh", "will think", "will run", "will sleep", "will talk", "will walk", "will write"]
    else:
        print("An error ocurred, restart the program and try again.")

    word = choice(words)
    return word

def get_preposition():
    words = ["about", "above", "across", "after", "along",
      "around", "at", "before", "behind", "below",
      "beyond", "by", "despite", "except", "for",
      "from", "in", "into", "near", "of",
      "off", "on", "onto", "out", "over",
      "past", "to", "under", "with", "without"]
    word = choice(words)
    return word

def get_prepositional_phrase(quantity):
    if quantity == 1:
        determiner = get_determiner(1)
        noun = get_noun(1)
        preposition = get_preposition()
    else:
        preposition = get_preposition()
        determiner = get_determiner(3)
        noun = get_noun(3)
    
    pre_phrase = f"{preposition} {determiner} {noun}"
    return pre_phrase
  
  
def make_sentence(quantity, tense):
    article = get_determiner(quantity)
    noun = get_noun(quantity)
    prep_phrase = get_prepositional_phrase(quantity)
    verb = get_verb(quantity, tense)

    sentece = f"{article.capitalize()} {noun} {verb} {prep_phrase}."
    return sentece

def main():
    sentence = make_sentence(1, "past")
    print(sentence)
    sentence = make_sentence(1, "present")
    print(sentence)
    sentence = make_sentence(1, "future")
    print(sentence)
    sentence = make_sentence(2, "past")
    print(sentence)
    sentence = make_sentence(2, "present")
    print(sentence)
    sentence = make_sentence(2, "future")
    print(sentence)

main()