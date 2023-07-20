[
    The purpose of this program is to add two values together
    and display the result.
]

+++++           Iterate 5 times
[
    >+++        Add 3 to cell one
    >++++       Add 4 to cell two
    <<-         Subtract 1 from cell zero
]

Currently cell one is 15 and cell two is 20
The resulting output should be 35

>[              Move to cell one and iterate until cell one is zero
    >+          Add 1 to cell two
    <-          Subtract 1 from cell one
]
>.              Print cell two