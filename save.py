__author__ = 'Sebi'

#import numpy as np
#import cPickle as pickle
import json

class save():

    def as_text(self, array, filename):

        #file = [0]*array.__len__()
        struc = {}
        for i in xrange(array.__len__()):
            struc[i] = array[i]
        data = dict(imgs=struc)
        file = open(filename, 'w')
        #pickle.dump(data, file)
        json.dump(data, file)

        """
        for i in xrange(array.__len__()):
            file[str(i)] = array[i]
        """
        #data = dict(imgs=file)
        #pickle.dump('data/clean/test/file.my_obj', dict(imgs=array))
