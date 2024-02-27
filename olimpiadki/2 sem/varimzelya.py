input_file_path = 'input10.txt'

with open(input_file_path, 'r') as file:
    lines = [line.strip() for line in file.readlines()]

actions_result = {}

def action_to_spell(action, ingredients):
    
    action_dict = {
        'MIX': 'MX',
        'WATER': 'WT',
        'DUST': 'DT',
        'FIRE': 'FR'
    }
    
    prefix_suffix = action_dict[action]
    return f'{prefix_suffix}{" ".join(ingredients)}{prefix_suffix[::-1]}'

spell = ""
for i, line in enumerate(lines):
    parts = line.split(' ')
    action = parts[0]
    ingredients = parts[1:]
    
    actions_result
    resolved_ingredients = []
    for ingredient in ingredients:
        if ingredient.isdigit():
            resolved_ingredients.append(actions_result[int(ingredient)])
        else: 
            resolved_ingredients.append(ingredient)
      
    action_word = action_to_spell(action, resolved_ingredients)
    actions_result[i+1] = action_word
    spell = action_word 
    ans = spell.replace(' ', '')
print(ans)
     
