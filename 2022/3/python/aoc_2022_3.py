test_data = ["vJrwpWtwJgWrhcsFMMfFFhFp","jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL","PmmdzqPrVvPwwTWBwg","wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn","ttgJtRGJQctTZtZT","CrZsJsPPZsGzwwsLwLmpwMDw"]

file = open("input.txt","r")

#file = test_data

total_score = 0

for line in file:    
    length = len(line)
    half = length//2
    found = False
    i = 0
    j = 0
    while ((i < half) and not found):
        j = half
        while ((j < length) and not found):    
            if (line[i] == line[j]):
                #print(line[i])
                if (line[i].isupper()):
                    #print(ord(line[i])-38)
                    total_score = total_score + ord(line[i])-38
                else:
                    #print(ord(line[i])-96)
                    total_score = total_score + ord(line[i])-96
                found = True
            j = j + 1
        i = i + 1


print(total_score)

############ PART 2

test_data = ["vJrwpWtwJgWrhcsFMMfFFhFp","jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL","PmmdzqPrVvPwwTWBwg","wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn","ttgJtRGJQctTZtZT","CrZsJsPPZsGzwwsLwLmpwMDw"]

file = open("input.txt","r")

#file = test_data

total_score = 0

count = 0
lineas = []

for line in file:
    if (count < 3):
        print(count)
        lineas.append(line)
        count = count + 1
        print(line)
        if (count == 3):
            count = 0
            found = False
            i = 0
            j = 0
            k = 0
            #print(lineas[0])
            #print(lineas[1])
            #print(lineas[2])
            while ((i < len(lineas[0])) and not found):        
                while ((j < len(lineas[1])) and not found):
                    while ((k < len(lineas[2])) and not found):
                        #print(lineas[0][i])
                        if (lineas[0][i] == lineas[1][j] == lineas[2][k]):
                            print(lineas[0][i])
                            if (lineas[0][i].isupper()):
                                #print(ord(line[i])-38)
                                total_score = total_score + ord(lineas[0][i])-38
                            else:
                                #print(ord(line[i])-96)
                                total_score = total_score + ord(lineas[0][i])-96
                            found = True
                        k = k + 1
                    k = 0
                    j = j + 1
                j = 0
                i = i + 1
            lineas = []

print(total_score)