# The Multiverse by Elder Costa.
#I added a question that can change where the game goes and a name option.

name = str(input("What is your name? "))
season = int(input("What is your favorite season? [1] - Summer\n[2] - Winter\n[3] - Spring\n[4] - Falls"))

print(f"You wake up in an unfamiliar place. You look to your surroundings, you are in an open field and you can't spot anything but grass and the horizon.\n")
path1 = input(f"You hear a voice calling your name \n'{name}'...\n What will you do? Will you FOLLOW the voice or WALK in the opposite direction?  ")

path1t = path1.lower()

if path1t == "follow":
    print("You decide to follow the voice. You walk towards where you think the sound is coming from...")
    path2 = input(f"You see a parrot, it speaks again 'Hi {name}. I am the multiverse parrot, I control this Lobby. Are you interested in staying here for a while?'. What will you do? Will you STAY, LEAVE or EAT the parrot?")
    path2t = path2.lower()

    if path2t == "stay":
        print("'Good' says the parrot, 'You see, we brought you here accidentally. This is another universe, it is quite chill so you can stay as long as you want, if you want to go home just say the word HOME loudly'.")
        path25 = input("What will you do? say HOME and return to your universe or STAY to enjoy the place?")
        path25t = path25.lower()

        if path25t == "stay":
            print("You decided to stay a little longer and enjoy the awesome view, after a while you decided you are bored and returns home. THE END 1")
        elif path25t == "home":
            print("You say HOME, you wake up on your bed, and after that you read The Book of Mormon. THE END 2")
        else:
            print("Invalid choice, restart the game XD")

    elif path2t == "leave":
        print("'Ok' the parrot says, 'Just say the word HOME loudly and you will return'.")
        path27 = input("What will you do? Will you go HOME already or will you stay and TALK to the bird?")
        path27t = path27.lower()

        if path27t == "home":
            print("You decide to go home. When you say the word HOME you wake up on your sofa, you decide to read the Bible. THE END 3")
        elif path27t == "talk":
            print("Tha parrot seems confused by the sudden will to talk. 'I don't want to be rude but I have work to do' says the parrot while he teleports you to your home. THE END 4")

    elif path2t == "eat":
        print("You try to eat the bird, it doesn't like it and uses magic to send you home. GAME OVER")
    else:
        print("Incorrect input, restart the game XD")

elif path1t == "walk":
    print("You decide to go to the opposite direction of the voice calling you.\nYou walk for a while and spot a village, it's a cozy place so you decide to go there and talk to someone.")
    path3 = input(f"You spot an old woman that appears to be a nice person, What will you do? TALK to the lady or GO away?")
    path3t = path3.lower()

    if path3t == "go" and season == 1:
        print("You decide to walk away... after a while you faint due to the heat of the summer, you wake up at home very confused. GAME OVER")

    elif path3t == "go" and season == 2 or season == 3 or season == 4:
        print("You decide to not talk since you are a bit shy. You walk all around the village and you don't see anything relevant, so you enter a shop to ask for information.")
        path35 = input("You enter the shop, you ask the seller where you are, he doesn't understand you. Will you REPEAT what you said or ask for directions to go HOME?")
        path35t = path35.lower()

        if path35t == "repeat":
            print("You repeat the question doing gestures to express your question. The seller says 'Você quer dizer CASA ou TRIANGULO?'.")
            path37 = input("You don't understand what he says but you need to choose CASA or TRIANGULO?")
            path37t = path37.lower()

            if path37t == "casa":
                print("When you say the word CASA, you teleport to your home, you feel very confused and think it is just a dream. (Play again and you might find why) THE END 5")
            elif path37t == "triangulo":
                print("You say TRIANGULO, the seller brings a triangle burguer, you pay for it and eat it, it is very good but you are sad you can't return home. BAD ENDING")
            else:
                print("Invalid command, restart the game XD")

    elif path3t == "talk":
        print("You talk to the old woman... she doesn't answer, you find her behaviour rude.")
        path39 = input("What will you do? REPEAT what you said or LEAVE?")
        path39t = path39.lower()

        if path39t == "repeat":
            print("You repeat more slowly... the old woman looks at you and you see she is a witch!")
            pathf = input("What will you do? FIGHT the witch or ASK for help?")
            pathft = pathf.lower()

            if pathft == "fight":
                print("You both fight an epic duel. After a while the witch lost and casts a spell that sends you to another universe. BAD ENDING")
            elif pathft == "ask":
                print("You ask her for help, she tells you that you just need to say HOME and you will return, you do so and find yourself home again. THE END 6")
            else:
                print("Invalid answer, restart the game")

        elif path39t == "leave":
            print("You leave her alone. You walk even further into the village... after a while the horizon gets twisted, your vision gets blurry and things seem like a fever dream.")
            final = input("You feel weird. What will you do? STOP and rest your head or KEEP going?")
            finalt = final.lower()

            if finalt == "stop":
                print("You stop and sit down, resting your head a little as you close your eyes... when you open them you are back home. THE END 7")
            elif finalt == "keep":
                print("You keep walking until all your vision goes white... you feel your guts moving and black out. When you wake up, you are on the same field as the beggining. BAD ENDING ")
            else:
                print("Invalid choice, restart the game XD")
        else:
            print("Invalid choice, restart the game XD")
    else:
        print("Invalid choice, restart the game XD")

else:
    print("Invalid choice, restart the game XD ")   