import csv
from datetime import datetime

current_date_and_time = datetime.now()
id_index = 0
id_quant = 1
id_price = 2
def main():

    products_dict = read_dictionary("products.csv", id_index)
    print("Inkom Emporium")
    try:
        with open("request.csv", "rt") as requests_csv:
            r_reader = csv.reader(requests_csv)
            next(r_reader)

            total_quantity = []
            sub_total = []
            for rows in r_reader:
                key = rows[id_index]
                quantity = int(rows[id_quant])
                getting_from = products_dict[key]
                name = getting_from[id_quant]
                price = float(getting_from[id_price])
                total_price = price * quantity
                total_quantity.append(quantity)
                sub_total.append(total_price)
                tax = sum(sub_total) * 0.06

                print(name, ": " , quantity," @ ", price)

            print("Number of items: ", sum(total_quantity))
            print(f"Subtotal:  {sum(sub_total):.2f}")
            print(f"Sales tax: {tax:.2f}")
            print(f"Total: {sum(sub_total) + tax:.2f}")
            print("Thank you for shopping at the Inkom Emporium.")
            print(current_date_and_time.strftime("%A %B %d %H:%M:%S %Y "))

    except FileNotFoundError as not_found_err:
        print(not_found_err)
    except PermissionError as perm_err:
        print(perm_err)

def read_dictionary(filename, key_column_index):
    dictionary = {}
    try:
        with open(filename, "rt") as csv_file:
            reader = csv.reader(csv_file)
            next(reader)

            for row in reader:
                key = row[key_column_index]
                dictionary[key] = row

        return dictionary
    except FileNotFoundError as not_found_err:
        print(not_found_err)
    except PermissionError as perm_err:
        print(perm_err)

if __name__ == "__main__":
    main()