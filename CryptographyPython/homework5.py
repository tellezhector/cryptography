import numbthy

dictionary = {}

p = 13407807929942597099574024998205846127479365820592393377723561443721764030073546976801874298166903427690031858186486050853753882811946569946433649006084171;
g = 11717829880366207009516117596335367088558084999998952205599979459063929499736583746670572176471460312928594829675428279466566527115212748467589894601965568;
h = 3239475104050450443565264378728065788649097520952449527834792452971981976143292558073856937958553180532878928001494706097394108577585732452307673444020333;
B = pow(2, 20);

def leftHand(x):
    aux = numbthy.powmod(g, x, p);
    [m, aux, y] = numbthy.xgcd(aux, p);
    aux = (aux * h) % p;
    aux =  aux % p;
    if(aux < 0):
        raise NameError('Aux less than zero.');
    return aux;

def rightHand(x):
    aux = numbthy.powmod(g, B, p);
    aux = numbthy.powmod(aux, x, p);
    aux = aux % p;
    if(aux < 0):
        raise NameError('Aux less than zero.');
    return aux

def fillDictionary():
    for i in range(B+1):
        if(i % 1000 == 0):
            print('filling dictionary, '+ str(i) + '/' + str(B+1) + ' entries so far.');
            
        key = leftHand(i);
        dictionary[key] = i;
    print('finished filling dictionary.')        


def findCollision():
    for i in range(357000, B+1):
        if(i % 1000 == 0):
            print('looking for collision, '+ str(i) + '/' + str(B+1) + ' entries so far.');
            
        r = rightHand(i);
        if (dictionary.get(r) != None):
            return [i, dictionary[r], (i*B)+dictionary[r]];
    return [0, 0, 0];

[x0, x1, x] = findCollision();
        

