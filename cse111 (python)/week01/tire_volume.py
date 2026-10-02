import math
import datetime
import os

# Getting current time and adding it to a variable
date = datetime.datetime.now()
date_formatted = date.strftime("%m-%d-%Y")

# Get the tire size from the user input
tire_size = input("Enter the tire size: (in USA format | e.g., 205/55-R16) ")

# Split the input into components
components = tire_size.split('-')

# Check if the input is in the correct format (XXX/YYY-RZZ)
if len(components) != 2 or 'R' not in components[1]:
    print("Invalid tire size format. Please use the correct format (e.g., 205/55-R16).")
else:
    # Parse the tire size
    width, aspect_ratio = components[0].split('/')
    diameter = components[1].split('R')[1]
    
    # Ensure the values are integers
    if not width.isdigit() or not aspect_ratio.isdigit() or not diameter.isdigit():
        print("Invalid input. Please enter numbers only.")
    else:
        width = int(width)
        aspect_ratio = int(aspect_ratio)
        diameter = int(diameter)

        # Apply the given formula to calculate the volume
        volume = (math.pi * width**2 * aspect_ratio * (width * aspect_ratio + 2540 * diameter)) / 10000000000

        # Print the volume
        print(f"The volume of the tire is approximately {volume:.2f} cubic millimeters.")

# Opening 'volumes.txt' for reading and appending
file_path = 'volumes.txt'

# Verifying if 'volumes.txt' exists
if not os.path.exists(file_path):
    # if it doesn't exist, it creates one
    with open(file_path, 'w') as file:
        print(f"The file '{file_path}' wasn't found. A new one was created.")
else:
    print(f"'{file_path}' found...\n")

# Inserting new data (variables) in the file
with open(file_path, 'a') as file:
    file.write(f"{date_formatted}, {width}, {aspect_ratio}, {diameter}, {volume:.2f}\n")

print("\nData updated")

# Reading current volumes.txt content
with open(file_path, 'r') as file:
    current_content = file.read()
    print("\n\nCurrent data:")
    print(current_content)