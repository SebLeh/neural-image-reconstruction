__author__ = 'Sebi'

import os
import cv2

from loader import MNIST

__all__ = [MNIST, ]
absPath = os.path.dirname(__file__)

mnist = MNIST(absPath)

imgs_test, labels_test = mnist.load_testing()

imgs_train, labels_train = mnist.load_training()

cv2.imshow('image', imgs_test[1])