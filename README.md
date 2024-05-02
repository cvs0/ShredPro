# ShredPro

This is a secure file shredder for windows, using various different algorithms to securely delete your files **permanently**.

## What is file shredding?

File shredding is overwriting a file with random data, then deleting it. We do this because when you delete a file it is not actually deleted, it just gets makred as deleted and stored in the "empty" drive space, it can still be recovered from this "empty" space and be read normally. Keep in mind, shredding a file will not prevent recovery, but when it is recovered it will be unreadable.

## Features
- Drag and drop file shredding
- GUI
- SDELETE integration
- Many different algorithms

## Algorithms
- Random data    (configurable number of passes)
- Zeroes         (configurable number of passes)
- DoD standard   (Department of Defence) (3 passes)
- Gutmann Method (35 passes)