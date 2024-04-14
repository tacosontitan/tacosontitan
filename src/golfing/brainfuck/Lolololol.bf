[
    This program is a proposed answer to the following stack exchange question:
    https://codegolf.stackexchange.com/questions/210976/lolololololololololololol

    The program is a simple loop that prints `L` then `ol` infinitely.
    L - 76
    o - 111
    l - 108
]

+           Add one to cell zero
[
    --      Subtract two from to the current cell
    >+      Move to the next cell and add one
    [<]     Move to the last cell with no value
    >-      Move to the next cell and subtract one
]
>-          Move to the next cell and subtract one
.           Print cell three