employees = []
items = []


def validate_employeeName():
    while True:
        eName = input("Enter employee's name: ")
        if eName:
            return eName
        else:
            print("Invalid input. Name cannot be empty. Please try again...")


def validate_employeeID():
    while True:
        eID = input("Please enter employee's ID:")
        if eID == "":
            print("The employee ID cannot be empty. Please try again...")
        elif not eID.isdigit():
            print("The employee ID must be a number. Please try again...")
        else:
            for employee in employees:
                if eID in employee:
                    print("The ID already existed in database. Please try again...")
                    break
            else:
                return eID


def validate_employeeType():
    while True:
        eType = input("Enter your employee's type (hourly/manager): ").lower()
        if eType == "hourly" or eType == "manager":
            return eType
        else:
            print("Invalid input. Employee type must be 'hourly' or 'manager'. Please try again...")


def validate_employeeDiscount():
    while True:
        eDisNum = input("Please enter employee's discount number:")
        if eDisNum == "":
            print("The employee Discount Number cannot be empty. Please try again...")
        elif not eDisNum.isdigit():
            print("The employee Discount Number must be a number. Please try again...")
        else:
            for employee in employees:
                if eDisNum in employee:
                    print("The Discount Number already existed in database. Please try again...")
                    break
            else:
                return eDisNum


def validate_employeeYear():
    while True:
        eYears = input("Please enter employee's years worked:")
        if eYears == "":
            print("The employee's years worked cannot be empty. Please try again...")
        elif not eYears.isdigit():
            print("The employee's years worked must be a number. Please try again...")
        else:
            return eYears


def print_employee_list():
    print("****EMPLOYEE SUMMARY****\n")
    print(
        "Employee ID | Employee Name | Employee Type | Years Worked | Total Purchased | Total Discount | Employee Discount Number")
    for employee in employees:
        data_strings = [str(x) for x in employee]
        summary_string = "       |".join(data_strings)
        print(summary_string)


def add_employee():
    e_choice = "Y"
    while e_choice != "N":
        eID = validate_employeeID()
        eName = validate_employeeName()
        eType = validate_employeeType()
        eYears = validate_employeeYear()
        eTotal = round(float(0), 2)
        eDiscount = 0
        eDisNum = validate_employeeDiscount()
        temp_list = [eID, eName, eType, eYears, eTotal, eDiscount, eDisNum]
        employees.append(temp_list)
        print("Successfully added new employee information to the database...")
        e_choice = input("Do you want to add another employee? (Y/N):").upper()
        while e_choice not in ["Y", "N"]:
            print("Invalid input, please try again.")
            e_choice = input("Do you want to add another employee? (Y/N): ").upper()


def page_direction():
    m_choice = input("Do you want to direct to the menu? (Y/N)").upper()
    while m_choice not in ["Y", "N"]:
        print("Invalid input, please try again.")
        m_choice = input("Do you want to the menu? (Y/N)").upper()
    if m_choice == "N":
        choice = "5"
        return choice


def validate_item_num():
    while True:
        iID = input("Please enter item's ID:")
        if iID == "":
            print("The item ID cannot be empty. Please try again...")
        elif not iID.isdigit():
            print("The item ID must be a number. Please try again...")
        else:
            for item in items:
                if iID in item:
                    print("The ID already existed in database. Please try again...")
                    break
            else:
                return iID


def validate_item_name():
    while True:
        iName = input("Enter item's name: ")
        if iName:
            return iName
        else:
            print("Invalid input. Name cannot be empty. Please try again...")


def validate_item_cost():
    while True:
        iCost = input("Please enter item's cost:")
        if iCost == "":
            print("The item cost cannot be empty. Please try again...")
        elif not iCost.isdigit():
            print("The item cost must be a number. Please try again...")
        else:
            return iCost


def add_item():
    e_choice = "Y"
    while e_choice != "N":
        item_num = validate_item_num()
        item_name = validate_item_name()
        item_cost = validate_item_cost()
        temp_list = [item_num, item_name, item_cost]
        items.append(temp_list)
        print("Successfully added new item information to the database...")
        e_choice = input("Do you want to add another item? (Y/N):").upper()
        while e_choice not in ["Y", "N"]:
            print("Invalid input, please try again.")
            e_choice = input("Do you want to add another item? (Y/N): ").upper()


def print_item_list():
    if len(items) == 0:
        print("Sorry! We are currently out of stock...")
        return False
    elif len(employees) == 0:
        print("Sorry! There is no employee in database...")
        return False
    else:
        print("****LIST OF AVAILABLE ITEMS****")
        print(
            "Item Number | Item Name | Item Cost")
        for item in items:
            data_strings = [str(x) for x in item]
            summary_string = "       |".join(data_strings)
            print(summary_string)

        return True


def make_purchase():
    item_price_total = 0
    working_year = ""
    employee_type = ""
    e_index = 0
    new_purchase = "Y"
    discount_amount = 0
    final_purchase = 0
    while new_purchase == "Y":
        temp_discount_num = input("Please input employee's discount number:")
        while True:
            for outer_index, employee in enumerate(employees):
                for inner_index, element in enumerate(employee):
                    if element == temp_discount_num:  # employee discount number
                        working_year = employee[3]  # get working year
                        employee_type = employee[2]  # get type
                        e_index = outer_index
                        print("Discount number has been applied successfully...")
                        break  # exit inner loop
                else:
                    continue  # continue outer loop
                break  # exit outer loop
            else:
                temp_discount_num = input("The employee's discount number is not correct. Please try again:")
                continue  # start over with a new input
            break  # exit the while loop

        temp_item_num = input("Please input the item number of product you want to purchase:")
        item_price = 0
        while True:
            for item in items:
                if item[0] == temp_item_num:
                    item_price = int(item[2])
                    print("Item added to basket...")
                    break
            else:
                temp_item_num = input("The item number is not correct. Please try again:")
                continue
            break

        discount_percent = min(int(working_year) * 2, 10)
        if employee_type == "manager":
            discount_percent += 10
        else:  # hourly
            discount_percent += 2

        discount_amount = min(item_price * discount_percent / 100, 200)

        eligible_discount_amount = 200 - employees[e_index][5]
        transaction_discount = min(discount_amount, eligible_discount_amount)
        final_purchase = item_price - transaction_discount

        confirmation = input("Confirm Purchase? (Y/N)").upper()
        while confirmation not in ["Y", "N"]:
            confirmation = input("Invalid input. Confirm Purchase? (Y/N)").upper()
        if confirmation == "Y":
            # total purchase update
            employees[e_index][4] += round(float(final_purchase), 2)
            # total discount update
            employees[e_index][5] += transaction_discount
        new_purchase = input("New Purchase? (Y/N)").upper()
        while new_purchase not in ["Y", "N"]:
            new_purchase = input("Invalid input. New Purchase? (Y/N)").upper()
    print_employee_list()


def print_menu():
    choice = 0

    while choice != "5":
        print("       **** MENU ****")
        menu = " ---------------------------" \
               "\n | 1- Create Employee      |" \
               "\n | 2- Create Item          | " \
               "\n | 3- Make Purchase        | " \
               "\n | 4-All Employee Summary  | " \
               "\n | 5-Exit                  |" \
               "\n ---------------------------\n"
        print(menu)
        choice = input("Please choose one of the option:")
        if choice == '1':
            add_employee()
            choice = page_direction()

        elif choice == '2':
            add_item()
            choice = page_direction()
        elif choice == '3':
            stock = print_item_list()
            if stock:
                make_purchase()
                choice = page_direction()
            else:
                choice = page_direction()
        elif choice == '4':
            print_employee_list()
            choice = page_direction()
        elif choice == '5':
            print("Thanks for using our program!")
        else:
            print("Invalid option. Try again.")


def main():
    print_menu()


if __name__ == "__main__":
    main()
