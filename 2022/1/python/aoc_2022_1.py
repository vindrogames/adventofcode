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