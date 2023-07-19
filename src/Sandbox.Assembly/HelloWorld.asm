    .data
output:
    .asciiz "Hello, world!\n"

    .text

main:
    li $v0, 4
    la $a0, output
    syscall

    li $v0, 10
    syscall