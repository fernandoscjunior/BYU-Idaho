#I used append() function to add the words's letters to a list


secret = "future"
guess = ""
guess_n = 0
secret_letter = len(secret)

print("Welcome to the Word guessing name!\n")
print("Your hint is", end=" ")
for i in secret:
    print("_ ", end="")

#try and error loop
while guess != secret:
    #guess
    guess = input()
    guess_n = guess_n + 1
    letter_number = len(guess)  

    #lenght verification
    if len(guess) != len(secret):
        print("The number of letters must be the same of the secret word.")


    resultado = []

    print("Your hint is", end=" ")

    for i in range(len(guess)):
        letter = secret[i]
        if guess[i] == secret[i]:
            resultado.append(i)
            print(letter.upper(), end=" ")


        elif guess[i] in secret:
            resultado.append(i)
            print(letter, end=" ")

        else:
            resultado.append('_')
            print("_", end=" ")
        

    #endgame check
    if guess == secret:
        print(f"Congratulations you guessed it! You took {guess_n} guesses. ")
    else:
        print("\nIncorrect try again\n")
