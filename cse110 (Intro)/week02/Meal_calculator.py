#I added a tip percentage

c_meal = float(input("What is the price of a child's meal? "))
n_child = int(input("How many children are there? "))
a_meal = float(input("What is the price of an adult's meal? "))
n_adult = int(input("How many adults are there? "))

#calculating the subtotal and showing subtotal
meal = c_meal * n_child + a_meal * n_adult
print(f"The subtotal is ${meal:.2f}.")

#Getting, calculating and showing taxes
tax = float(input("What is the sale tax rate? (insert in percentage) "))
taxes = meal * tax / 100
print(f"The tax amount is ${taxes:.2f}.")

#Showing final price
print(f"The final price is ${meal + taxes:.2f}")

#Asking for tip and payment
tip = float (input("What is the tip percentage?"))
pay = float(input("What is the payment amount? "))

#Calculating tip percentage
total = pay * tip / 100

#Showing final price
print(f"(The price with the tip is ${pay + total:.2f}).")

#Caalculating and showing change
change = meal + taxes + total - pay
print(f"The change is ${change:.2f}")