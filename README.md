# RPG Characters
A console application written in C#. 
## Table of Contents
- [Description](#Description)
- [Installation](#Installation)
- [Components](#Components)
- [Usage](#Usage)
- [Maintainer](#Maintainer)
- [Author](#Author)
- [License](#License)
## Description
This project has various character classes having attributes which increase at different rates as the character gains levels.
Equipment, such as armor and weapons, that characters can equip. The equipped items will alter the power of the character,
causing it to deal more damage. Certain characters can equip certain item types.
No program.cs is implemeted.

## Installation
Run it in Visual Studios, then press the play button.


## Components
Two custom exceptions.
A Characer class that extendes four character classes (Mage, Warrior, Rouge and Rangers). 
A Item class that extendes two item classes (Armor and Weapon)
Tests for characters attributes and leveling system.
Tests for item system.
Summary tags for all classes and methods.

## Usage

The Character class ToString method is overwritten to show the characters stats.
```C#
# returns 'Characters stats'
public override string ToString()

```
To use it:

```C#
Warrior warrior = new("Warrior");
Console.WriteLine(warrior);

```
## Maintainer
[@emiliozimberlin](https://gitlab.com/emiliozimberlin)

## Author
Emilio Zimberlin
## License
[MIT](https://choosealicense.com/licenses/mit/)
