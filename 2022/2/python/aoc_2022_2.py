test_data = ["A Y","B X","C Z"]

file = open("input.txt","r")

#file = test_data
total_score = 0
for line in file:    
    j1 = line[0]
    j2 =  line[2]
    jugador1 = 0
    jugador2 = 0
    if (j1 == 'A'):
        jugador1 = 1
    if (j1 == 'B'):
        jugador1 = 2
    if (j1 == 'C'):
        jugador1 = 3
    if (j2 == 'X'):
        jugador2 = 1
    if (j2 == 'Y'):
        jugador2 = 2
    if (j2 == 'Z'):
        jugador2 = 3
    
    if (jugador1 == jugador2):
        total_score = total_score + 3 + jugador2
    if (jugador1 == 1 and jugador2 ==2):
        total_score = total_score + 6 + jugador2
    if (jugador1 == 1 and jugador2 ==3):
        total_score = total_score + 0 + jugador2
    if (jugador1 == 2 and jugador2 ==1):
        total_score = total_score + 0 + jugador2
    if (jugador1 == 2 and jugador2 ==3):
        total_score = total_score + 6 + jugador2
    if (jugador1 == 3 and jugador2 ==1):
        total_score = total_score + 6 + jugador2
    if (jugador1 == 3 and jugador2 ==2):
        total_score = total_score + 0 + jugador2    

print(total_score)

############ PART 2

test_data = ["A Y","B X","C Z"]

file = open("input.txt","r")

#file = test_data

total_score = 0
for line in file:    
    j1 = line[0]
    j2 =  line[2]
    jugador1 = 0
    jugador2 = 0
    if (j1 == 'A'):
        jugador1 = 1
        if (j2 == 'X'): # you need to lose
            jugador2 = 3
        if (j2 == 'Y'): # you need to draw
            jugador2 = 1
        if (j2 == 'Z'): # you need to win
            jugador2 = 2
    if (j1 == 'B'):
        jugador1 = 2
        if (j2 == 'X'): # you need to lose
            jugador2 = 1
        if (j2 == 'Y'): # you need to draw
            jugador2 = 2
        if (j2 == 'Z'): # you need to win
            jugador2 = 3

    if (j1 == 'C'):
        jugador1 = 3        
        if (j2 == 'X'): # you need to lose
            jugador2 = 2
        if (j2 == 'Y'): # you need to draw
            jugador2 = 3
        if (j2 == 'Z'): # you need to win
            jugador2 = 1

    
    if (jugador1 == jugador2):
        total_score = total_score + 3 + jugador2
    if (jugador1 == 1 and jugador2 ==2):
        total_score = total_score + 6 + jugador2
    if (jugador1 == 1 and jugador2 ==3):
        total_score = total_score + 0 + jugador2
    if (jugador1 == 2 and jugador2 ==1):
        total_score = total_score + 0 + jugador2
    if (jugador1 == 2 and jugador2 ==3):
        total_score = total_score + 6 + jugador2
    if (jugador1 == 3 and jugador2 ==1):
        total_score = total_score + 6 + jugador2
    if (jugador1 == 3 and jugador2 ==2):
        total_score = total_score + 0 + jugador2    

print(total_score)