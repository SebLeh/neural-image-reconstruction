__author__ = 'Sebi'

import struct
"""
import cv2
import numpy
import matplotlib.pyplot as plt
"""
from array import array


class MNIST(object):
    def __init__(self, path='.'):
        self.path = path

        self.test_img_fname = 't10k-images.idx3-ubyte'
        self.test_lbl_fname = 't10k-labels.idx1-ubyte'

        self.train_img_fname = 'train-images.idx3-ubyte'
        self.train_lbl_fname = 'train-labels.idx1-ubyte'

        self.test_images = []
        self.test_labels = []

        self.train_images = []
        self.train_labels = []

    def load_testing(self):
        ims, labels = self.load((self.path + '/data/' + self.test_img_fname),
                                (self.path + '/data/' + self.test_lbl_fname))

        self.test_images = ims
        self.test_labels = labels

        return ims, labels

    def load_training(self):
        ims, labels = self.load((self.path + '/data/' + self.train_img_fname),
                                (self.path + '/data/' + self.train_lbl_fname))

        self.train_images = ims
        self.train_labels = labels

        return ims, labels

    @classmethod
    def load(cls, path_img, path_lbl):
        with open(path_lbl, 'rb') as file:
            magic, size = struct.unpack(">II", file.read(8))
            if magic != 2049:
                raise ValueError('Magic number mismatch, expected 2049,'
                                 'got {}'.format(magic))

            labels = array("B", file.read())

        with open(path_img, 'rb') as file:
            magic, size, rows, cols = struct.unpack(">IIII", file.read(16))
            if magic != 2051:
                raise ValueError('Magic number mismatch, expected 2051,'
                                 'got {}'.format(magic))

            image_data = array("B", file.read())

        images = []
        for i in range(size):
            images.append([0] * rows * cols)

        for i in range(size):
            images[i][:] = image_data[i * rows * cols:(i + 1) * rows * cols]

        """
        im_array = images[0]
        img = [[0]*28 for x in xrange(28)]
        for j in range(784):
            x = int(j / 28)
            y = j % 28
            img[x][y] = im_array[j]

        im = numpy.asarray(img)
        plt.imshow(im)
        #cv2.imshow('7?', im)
        """

        return images, labels

    @classmethod
    def display(cls, img, width=28, threshold=200):
        render = ''
        for i in range(len(img)):
            if i % width == 0:
                render += '\n'
            if img[i] > threshold:
                render += '@'
            else:
                render += '.'
        return render