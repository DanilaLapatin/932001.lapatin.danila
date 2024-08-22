import turtle

iterations = 4
angle = 60
distance = 5


d = {
    '0':'Снежинка Коха',
    '1':'Дракон Хартера-Хатвея',
    '2': 'Кривая Гильберта',
    '3': 'Дерево 1',
    '4': 'Дерево 2',
    '5': 'Дерево 3',
    '6': 'Дерево 4',
    '7': 'Ковёр Серпинского'
}
ruleslist = {
    #Снежинка Коха angle=60 iterations = 4 distance = 5
    '0': {
        'iterations' : 4,
        'angle' : 60,
        'distance' : 5,
        "S": "F++F++F",
        "F": "F-F++F-F",
        },
    #Дракон Хартера-Хатвея angle=90 iterations = 20 distance = 1
    '1': {
        'iterations' : 20,
        'angle' : 90,
        'distance' : 1,
        "S": "FX",
        "F": "F",
        "X": "X+YF+",
        "Y": "-FX-Y",
        },
    #Кривая Гильберта angle=90 iterations = 5 distance = 5
    '2': {
        'iterations' : 5,
        'angle' : 90,
        'distance' : 5,
        "S": "X",
        "F": "F",
        "X": "-YF+XFX+FY-",
        "Y": "+XF-YFY-FX+",
        },
    #TREES
    #Дерево 1 angle=25.7 iterations = 4 distance = 10
    '3': {
        'iterations' : 4,
        'angle' : 25.7 ,
        'distance' : 10,
        "S": "F",
        "F": "F[+F]F[-F]F",
        },
    #Дерево 2 angle=20 iterations = 4 distance = 10
    '4': {
        'iterations' : 4,
        'angle' : 20,
        'distance' : 10,
        "S": "F",
        "F": "F[+F]F[-F][F]",
        },
    #Дерево 3 angle=25.7 iterations = 6 distance = 5
    '5': {
        'iterations' : 6,
        'angle' : 25.7 ,
        'distance' : 5,
        "S": "X",
        "F": "FF",
        "X": "F[+X][-X]FX",
        },
    #Дерево 4 angle=20  distance = 10
    '6': {
        'iterations' : 6,
        'angle' : 20 ,
        'distance' : 10,
        "S": "F",
        "F": "-F[-F+F-F]+[+F-F-F]",
        },
    # Ковёр Серпинского angle = 60 iterations = 1, TOP: 10
    '7':{
        'iterations' : 10,
        'angle' : 60 ,
        'distance' : 10,
        "S":"YF",
        "X":"YF+XF+Y", 
        "Y":"XF-YF-X",
    }
} 

print(d)


fractal = input('введите номер фрактала:')
print('Рисуем фрактал "'+d[fractal]+'"'+'\n')

rules = ruleslist[fractal]
iterations = rules['iterations']
angle = rules['angle']
distance = rules['distance']



def apply_rules(s, rules):
    result = ""
    for char in s:
        if char in rules:
            result += rules[char]
        else:
            result += char
    return result

def draw_fractal(s, angle, distance):
    t = turtle.Turtle()
    t.speed(0)
    stack = []
    if 'Дерево' in fractal:
        t.left(90)

    for char in s:
        if char == 'F' or char == 'X' or char == 'Y':
            t.forward(distance)
        elif char == '+':
            t.right(angle)
        elif char == '-':
            t.left(angle)
        elif char == '[':
            stack.append((t.position(), t.heading()))
        elif char == ']':
            position, heading = stack.pop()
            t.penup()
            t.goto(position)
            t.setheading(heading)
            t.pendown()
    turtle.done()

start = "S"


for _ in range(iterations):
    start = apply_rules(start, rules)

draw_fractal(start, angle, distance)