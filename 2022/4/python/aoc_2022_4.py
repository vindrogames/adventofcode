import re

test_data = ["2-4,6-8","2-3,4-5","5-7,7-9","2-8,3-7","6-6,4-6","4-4,2-34"]

file = open("input.txt","r")

#file = test_data

total_score = 0

for line in file:
    result = re.search(r"(\d+)-(\d+),(\d+)-(\d+)", line)
    #print(result.groups())
    first1 = int(result.group(1))
    first2 = int(result.group(2))
    second1 = int(result.group(3))
    second2 = int(result.group(4))
    #print(second1)

    if ( (first1 <= second1) and (first2 >= second2)):
        #print(result.groups())
        total_score = total_score + 1
    elif ( (second1 <= first1) and (second2 >= first2)):
        #print(result.groups())
        total_score = total_score + 1

print(total_score)

############ PART 2

test_data = ["8-44,6-8","2-3,4-5","5-7,7-9","2-8,3-7","6-6,4-6","2-6,4-8"]

file = open("input.txt","r")

#file = test_data

total_score = 0

count = 0
lineas = []

for line in file:
    result = re.search(r"(\d+)-(\d+),(\d+)-(\d+)", line)
    first1 = int(result.group(1))
    first2 = int(result.group(2))
    second1 = int(result.group(3))
    second2 = int(result.group(4))
    if ( (first2 >= second1) and first1 <= second2):
        print(result.groups())
        total_score = total_score + 1
print(total_score)