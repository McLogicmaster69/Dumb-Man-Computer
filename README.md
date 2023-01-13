# Dumb-Man-Computer

First text box: Commands (stated below)
Second text box: Simplified commands (not to edit)
Third text box: Commands converted to binary (not to edit)
Fourth text box: Output
Fifth text box: Variable watch list. Will output trace table at the end
Number input: Inputs number when program asks for one

# FORMAT

(Label name for statement [optional]) (Command [required]) (Parameter [optional] {number or label})

# COMMANDS:


Command name: description [parameter]


HLT: Stops the program

ADD: Adds number stored in memory address to accumulator [Memory address {Add "-" sign to fetch the address in this memory address, making it a pointer}]

SUB: Subtracts number stored in memory address from accumulator [Memory address {Add "-" sign to fetch the address in this memory address, making it a pointer}]

MUL: Multiply accumulator by number stored in memory address [Memory address {Add "-" sign to fetch the address in this memory address, making it a pointer}]

DIV: Divide accumulator by number stored in memory address [Memory address {Add "-" sign to fetch the address in this memory address, making it a pointer}]

ADN: Adds number to accumulator [Number]

SUN: Subtracts number from accumulator [Number]

MUN: Multiplies accumulator by number [Number]

DIN: Divides accumulator bu number [Number]

SET: Sets accumulator to value [Number]

STA: Stores accumulator to memory address [Memory address {Add "-" sign to fetch the address in this memory address, making it a pointer}]

LDA: Loads from memory address to accumulator [Memory address {Add "-" sign to fetch the address in this memory address, making it a pointer}]

INP: Store input in accumulator []

OUT: Output accumulator []

BRA: Always go to memory address [Memory address]

BRZ: Go to memory address when accumulator is 0 [Memory address]

BRP: Go to memory address when accumulator is positive (including 0) [Memory address]

DAT: Marks memory address as data for the interpreter [Initial value]

CON: Marks memory address as blank for the interpreter [Times to repeat CON statement {Helpful for pointers and arrays}]

LBS: Left binary shifts the accumulator [Shift value]

RBS: Right binary shifts the accumulator [Shift value]

LBR: Left binary rotates the accumulator [Shift value]

RBR: Right binary rotates the accumulator [Shift value]

# GRAPHICAL COMMANDS

GRO: Opens graphics tab []

GRC: Closes graphics tab []

GRR: Refreshes graphics tab []

GRP: Changes pixel size (default: 10) [Value]

GRW: Changes canvas width (default: 20) [Value]

GRH: Changes canvas height (default: 20) [Value]

GRE: Enables pixel value [Position in array {if 5x5 array, if you want position (2, 3), you must input 5 * 2 + 3 as it is one continues array of pixels}]

GRD: Disables pixel value [Position in array {if 5x5 array, if you want position (2, 3), you must input 5 * 2 + 3 as it is one continues array of pixels}]

GRS: Switches pixel value [Position in array {if 5x5 array, if you want position (2, 3), you must input 5 * 2 + 3 as it is one continues array of pixels}]