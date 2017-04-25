# Algorithm_Collection
Collection of Algorithms

Features the following algorithms:
- Dijkstra algorithm 
- A* algorithm
- RSA encryption
- Sort algorithms
  - Stupid sort
  - Quick sort
  - Comb sort
  - Selection sort 
  - Insertion sort
  - Bubble sort
  
Usage of the Sorting algorithms:
To use the sort algorithms, simply create a new instance of the MyList class.
Add the elements to the list and call the wanted function.

Usage of the RSA Encryption:
Get the instance of the EncryptionManager. 
```C#
  EncryptionManager manager = EncryptionManager.Instance;
'''

To generate a new key pair, call:
```C#
  KeyPair keyPair = manager.GenerateKeyPair("RandomPassword");
'''
The longer the password, the more secure the key pair will be.

To encrypt a message, call:
```C#
  string mess = manager.EncryptStringMessage("Hello World", keyPair.PublicKey);
'''

Decryption goes as follows:
To encrypt a message, call:
```C#
  mess = manager.DecryptStringMessage(mess, keyPair.PrivateKey);
'''
