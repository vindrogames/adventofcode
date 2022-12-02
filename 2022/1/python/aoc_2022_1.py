file = open("input.txt","r")
suma = 0
maxima_suma = 0
for line in file:    
    if line.strip('\n') == "":        
        if suma > maxima_suma:
            maxima_suma = suma
        suma = 0
    else:        
        food = int(line.strip('\n'))
        suma = suma + food
print(maxima_suma)

######## PART 2

file = open("input.txt","r")
suma = 0
top1 = 0
top2 = 0
top3 = 0
for line in file:    
    if line.strip('\n') == "":        
        if suma > top1:
            top3 = top2
            top2 = top1
            top1 = suma
        elif suma > top2:
            top3 = top2
            top2 = suma
        elif suma > top3:
            top3 = suma
        suma = 0
    else:        
        food = int(line.strip('\n'))
        suma = suma + food
print(top1+top2+top3)