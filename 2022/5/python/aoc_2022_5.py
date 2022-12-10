import re

crates_data = "crates.txt"
test_data = ["move 1 from 2 to 1","move 3 from 1 to 3","move 2 from 2 to 1","move 1 from 1 to 2"]

file = open(crates_data,"r")

#file = test_data

crates = []

primera_linea = 0
cuenta_linea = 0

for line in file:
    cuenta_linea = len(line)

print((cuenta_linea + 1)//4)

numero_columnas = (cuenta_linea + 1)//4

for i in range(numero_columnas):
    crates.append([])



file = open(crates_data,"r")

for line in file:
    initial_char = 1
    secuencia = 0    
    while (initial_char < len(line)):
        character = line[initial_char]        
        if (character != ' ' and (not re.search('\d+', character))):
            #print(character)
            crates[secuencia].append(character)        
        initial_char = initial_char + 4
        secuencia = secuencia + 1

#print(crates)

#invert crates inside array

for a in crates:
    a.reverse()

print(crates)

file_data = open("input.txt","r")

#file_data = test_data

for line in file_data:
    result = re.search(r"move (\d+) from (\d+) to (\d+)", line)
    how_many = int(result.group(1))
    from_column = int(result.group(2))
    to_column = int(result.group(3))
    #print(how_many,from_column,to_column)

    item_stack = []

    for i in range(how_many):
        # PART 1 uncomment
        #item = crates[from_column-1].pop()
        #crates[to_column-1].append(item)
        # PART 1 end

        # PART 2
        item_stack.append(crates[from_column-1].pop())
    
    # PART 2 commen the whole for
    for i in range(how_many):
        crates[to_column-1].append(item_stack.pop())
    # end of PART 2

print(crates)

for a in crates:
    print(a.pop())

##########################################
# PART 2

