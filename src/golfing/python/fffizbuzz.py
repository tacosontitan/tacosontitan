n = 20
for i in range(1,n+1):
    f=b=0;x=y=i
    while x%3<1:f+=1;x/=3
    while y%5<1:b+=1;y/=5
    print('Fizz'*f+'Buzz'*b or i)
