import re

test_data = ["mjqjpqmgbljsphdztnvjfqwrcgsmlb","bvwbjplbgvbhsrlpgdmjqwftvncz","nppdvjthqldpwncqszvftbrmjlhg","nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg","zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"]

file = open("input.txt","r")

#file = test_data

total_score = 0

posicion = 0

for line in file:
    longitud = len(line)
    i = 0
    found = False
    while ( (i < longitud-3) and (not found) ):
        char1 = line[i]
        char2 = line[i+1]
        char3 = line[i+2]
        char4 = line[i+3]
        
        if ( (char1 != char2) and (char1 != char3) and (char1 != char4) and (char2 != char3) and (char2 != char4) and (char3 != char4 ) ):
            found = True
            #print(char1, char2, char3, char4)
            total_score = total_score + 1
            posicion = i + 4

        i = i + 1
    
    print(posicion)

print(total_score)

# PART 2

file = open("input.txt","r")

#file = test_data

total_score = 0

posicion = 0

DISTINCT_CHARACTERS = 14

chars = [5]*DISTINCT_CHARACTERS
print(chars)

for line in file:
    longitud = len(line)
    i = 0
    found = False
    while ( (i < longitud-DISTINCT_CHARACTERS+1) and (not found) ):

        for x in range(DISTINCT_CHARACTERS):
            #print(i,x)
            chars[x] = line[i+x]
        chars_ordenado = chars
        chars_ordenado.sort()
        #print(chars_ordenado)

        # ahora vamos a buscar 2 caracteres iguales consecutivos
        longitud_chars_ordenado = len(chars_ordenado)
        j = 0
        hay_igual = False
        while ( (j < longitud_chars_ordenado - 1) and (not hay_igual) ):
            char11 = chars_ordenado[j]
            char22 = chars_ordenado[j+1]
            if ( char11 == char22):
                hay_igual = True
                #print(chars_ordenado)
            j = j + 1
        found = not hay_igual
        total_score = total_score + 1
        i = i + 1
    print(total_score+DISTINCT_CHARACTERS-1)
    total_score = 0

