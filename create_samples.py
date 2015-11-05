__author__ = 'Sebi'

import os
import matplotlib.pyplot as plt
import matplotlib.image as mpimg
import numpy as np
import random
import array
import cv2

from noise import noise
from loader import MNIST
from save import save

__all__ = [MNIST, ]
absPath = os.path.dirname(__file__)

mnist = MNIST(absPath)
noise = noise()


imgs_test, labels_test = mnist.load_testing()

test_gauss_5 = np.zeros(50, dtype=object)
test_gauss_10 = np.zeros(50, dtype=object)
test_gauss_15 = np.zeros(50, dtype=object)
test_snp_002 = np.zeros(50, dtype=object)
test_snp_005 = np.zeros(50, dtype=object)
test_snp_01 = np.zeros(50, dtype=object)
test_5_005 = np.zeros(50, dtype=object)
test_10_002 = np.zeros(50, dtype=object)
test_15_01 = np.zeros(50, dtype=object)
test_random = np.zeros(50, dtype=object)

for i in xrange(50):
    im_arr = imgs_test[i]
    img = [[0]*28 for x in xrange(28)]
    for j in range(784):
        x = int(j / 28)
        y = j % 28
        img[x][y] = im_arr[j]
    im = np.asarray(img)
    #test_clean[i] = im_arr
    #cv2.imwrite(('data/clean/samples/'+'img_'+str(i)+'.png'), im)


    gauss_5 = noise.gauss(im, 5)
    cv2.imwrite(('data/noisy/samples/gauss_5/'+'img_'+str(i)+'.png'), gauss_5)
    gauss_10 = noise.gauss(im, 10)
    cv2.imwrite(('data/noisy/samples/gauss_10/'+'img_'+str(i)+'.png'), gauss_10)
    gauss_15 = noise.gauss(im, 15)
    cv2.imwrite(('data/noisy/samples/gauss_15/'+'img_'+str(i)+'.png'), gauss_15)
    snp_002 = noise.s_and_p(im, 0.5, 0.02)
    cv2.imwrite(('data/noisy/samples/snp_002/'+'img_'+str(i)+'.png'), snp_002)
    snp_005 = noise.s_and_p(im, 0.5, 0.05)
    cv2.imwrite(('data/noisy/samples/snp_005/'+'img_'+str(i)+'.png'), snp_005)
    snp_01 = noise.s_and_p(im, 0.5, 0.1)
    cv2.imwrite(('data/noisy/samples/snp_01/'+'img_'+str(i)+'.png'), snp_01)

    gauss_5_snp_005 = noise.s_and_p(im, 0.5, 0.05)
    gauss_5_snp_005 = noise.gauss(gauss_5_snp_005, 5)
    cv2.imwrite(('data/noisy/samples/gauss_5_snp_005/'+'img_'+str(i)+'.png'), gauss_5_snp_005)

    gauss_10_snp_002 = noise.s_and_p(im, 0.5, 0.02)
    gauss_10_snp_002 = noise.gauss(gauss_10_snp_002, 10)
    cv2.imwrite(('data/noisy/samples/gauss_10_snp_002/'+'img_'+str(i)+'.png'), gauss_10_snp_002)

    gauss_15_snp_01 = noise.s_and_p(im, 0.5, 0.1)
    gauss_15_snp_01 = noise.gauss(gauss_15_snp_01, 15)
    cv2.imwrite(('data/noisy/samples/gauss_15_snp_01/'+'img_'+str(i)+'.png'), gauss_15_snp_01)

    rnd_gauss = random.randint(5, 25)
    rnd_snp = random.uniform(0.05, 0.1)
    rand = noise.s_and_p(im, 0.5, rnd_snp)
    rand = noise.gauss(rand, rnd_gauss)
    cv2.imwrite(('data/noisy/samples/random/'+'img_'+str(i)+'.png'), rand)
