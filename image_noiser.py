__author__ = 'Sebi'

import os
import matplotlib.pyplot as plt
import numpy as np

from loader import MNIST

__all__ = [MNIST, ]
absPath = os.path.dirname(__file__)

mnist = MNIST(absPath)

imgs_test, labels_test = mnist.load_testing()

imgs_train, labels_train = mnist.load_training()

#for i in xrange(imgs_train.__len__()):
im_array = imgs_train[0]
img = [[0]*28 for x in xrange(28)]
for j in range(784):
    x = int(j / 28)
    y = j % 28
    img[x][y] = im_array[j]

im = np.asarray(img)
noisy = noisy("gauss", im)


def noisy(noise_typ, image):

    if noise_typ == "gauss":
        row, col, ch = image.shape
        mean = 0
        #var = 0.1
       #sigma = var**0.5
        gauss = np.random.normal(mean, 1, (row, col, ch))
        gauss = gauss.reshape(row, col, ch)
        noisy = image + gauss
        return noisy
    elif noise_typ == "s&p":
        row, col, ch = image.shape
        s_vs_p = 0.5
        amount = 0.004
        out = image
        # Salt mode
        num_salt = np.ceil(amount * image.size * s_vs_p)
        coords = [np.random.randint(0, i - 1, int(num_salt))
                  for i in image.shape]
        out[coords] = 1

        # Pepper mode
        num_pepper = np.ceil(amount* image.size * (1. - s_vs_p))
        coords = [np.random.randint(0, i - 1, int(num_pepper))
                  for i in image.shape]
        out[coords] = 0
        return out
    elif noise_typ == "poisson":
        vals = len(np.unique(image))
        vals = 2 ** np.ceil(np.log2(vals))
        noisy = np.random.poisson(image * vals) / float(vals)
        return noisy
    elif noise_typ =="speckle":
        row, col, ch = image.shape
        gauss = np.random.randn(row, col, ch)
        gauss = gauss.reshape(row, col, ch)
        noisy = image + image * gauss
        return noisy