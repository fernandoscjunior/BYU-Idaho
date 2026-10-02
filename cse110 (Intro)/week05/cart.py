#Author: Elder Costa © 2025
#Description: A shopping cart application
#Showing creativity: I added an option to pay the total amount, 
#by doing so the items are removed and the the final price is reseted

#Declaring global variables
choice = 0
items = []
prices = []
final_price = 0

#Main loop
while choice != 5:
    print("\nWelcome to the shopping menu!")
    choice = int(input("What would you like to do?\n[1] - Add an item to the shopping cart\n[2] - Display cart items\n[3] - Remove an item\n[4] - Display total\n[5] - Quit "))

    if choice == 1:
        item_name = input("What is the name of the item you want to add? ")
        item_price = float(input(f"What is the price of '{item_name}'? "))

        items.append(item_name)
        prices.append(item_price)
        
        print(f"'{item_name}' has been added to the cart.")

    elif choice == 2:
        print("\nThe content of the shopping cart are:")

        for i in range(len(items)):
            temporary_item = items[i]
            temporary_price = prices[i]
            print(f"{i + 1}. {temporary_item} - ${temporary_price:.2f}")

    elif choice == 3:
        print("\nThe content of the shopping cart are:")

        for i in range(len(items)):
            temporary_item = items[i]
            temporary_price = prices[i]
            print(f"{i + 1}. {temporary_item} - ${temporary_price:.2f}")

        remove = int(input("\n What item would you like to remove?"))
        if remove > i + 1:
            print("Invalid request, try again.")
        else:
            items.pop(remove - 1)
            prices.pop(remove - 1)

    elif choice == 4:
        for price in prices:
            final_price += price
        
        print(f"\nThe final price is ${final_price:.2f}")

        will_pay = int(input("\nWould you like to pay? \n[1] - Yes\n[2] - No "))
        if will_pay == 1:
            pay = float(input("\nPlease insert the value: "))

            if pay != final_price:
                print("\nThis amount isn't enough, please try again.")
            else:
                prices = []
                items = []
                final_price = 0

        elif will_pay == 2:
            print("\nAlright. Redirecting...")
            final_price = 0

        else:
            print("\nInvalid request, try again.")
            final_price = 0

    else:
        print("Thanks for using the program!\nLOGGING OUT...")
        choice = 5