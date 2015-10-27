__author__ = 'Sebi'

#import numpy as np
#import cPickle as pickle
import json
import numpy as np

class save():

    def as_text(self, array, filename):
        struc = {}
        file = open(filename, 'w')

        for i in xrange(array.__len__()):
            #arr[i] = array[i]

            struc[i] = str(array[i])
            if i == array.__len__()-1:
                struc[i+1] = '_'
            #file.write(struc[i])
        #data = dict(imgs=struc)
        #pickle.dump(data, file)
        #json.dump(data, file)
        #file.write(data)

        for i in xrange(array.__len__()+1):
            file.write(struc[i])
        file.close()

        """
        for i in xrange(array.__len__()):
            file[str(i)] = array[i]
        """
        #data = dict(imgs=file)
        #pickle.dump('data/clean/test/file.my_obj', dict(imgs=array))
