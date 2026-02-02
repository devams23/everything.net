### Performance impact of boxing :



* so extensive boxing can lead to allocating more object to the heap memory, which can add a big overhead, and thus making the code run slower , compare to generic ones.
* also due to the lot of objects in the heap the garbage collector required frequent cycles to , remove the unused object, thus using much higher cpu.
* boxing will store the data in the heap, which can result in cache miss, as the cpu will not search for the cached data in the stack and look for the data in the heap, which is slower,



# 

