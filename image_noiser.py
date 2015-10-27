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
filesave = save()



def serialize(image):
    im_array = np.zeros(784, np.int32)
    #im_array = array.array('i', (0 for k in range(784)))
    k = 0
    for i in xrange(image.__len__()):
        for j in xrange(image[i].__len__()):
            im_array[k] = int(round(image[i, j]))
            if im_array[k] < 0:
                im_array[k] = 0
            k = k + 1
    return im_array

im_test, labels_test = mnist.load_testing()
imgs_test = im_test[:10]

#test_clean = np.empty(imgs_test.__len__(), dtype=object)
test_clean = np.zeros(imgs_test.__len__(), dtype=object)
test_gauss_5 = np.zeros(imgs_test.__len__(), dtype=object)
test_gauss_10 = np.zeros(imgs_test.__len__(), dtype=object)
test_gauss_15 = np.zeros(imgs_test.__len__(), dtype=object)
test_snp_002 = np.zeros(imgs_test.__len__(), dtype=object)
test_snp_005 = np.zeros(imgs_test.__len__(), dtype=object)
test_snp_01 = np.zeros(imgs_test.__len__(), dtype=object)
test_5_005 = np.zeros(imgs_test.__len__(), dtype=object)
test_10_002 = np.zeros(imgs_test.__len__(), dtype=object)
test_15_01 = np.zeros(imgs_test.__len__(), dtype=object)
test_random = np.zeros(imgs_test.__len__(), dtype=object)

for i in xrange(imgs_test.__len__()):
    im_arr = imgs_test[i]
    img = [[0]*28 for x in xrange(28)]
    for j in range(784):
        x = int(j / 28)
        y = j % 28
        img[x][y] = im_arr[j]
    im = np.asarray(img)
    test_clean[i] = im_arr
    #cv2.imwrite(('data/clean/test/'+'img_'+str(i)+'.png'), im)


    gauss_5 = noise.gauss(im, 5)
    test_gauss_5[i] = serialize(gauss_5)
    gauss_10 = noise.gauss(im, 10)
    test_gauss_10[i] = serialize(gauss_10)
    gauss_15 = noise.gauss(im, 15)
    test_gauss_15[i] = serialize(gauss_15)
    snp_002 = noise.s_and_p(im, 0.5, 0.02)
    test_snp_002[i] = serialize(snp_002)
    snp_005 = noise.s_and_p(im, 0.5, 0.05)
    test_snp_005[i] = serialize(snp_005)
    snp_01 = noise.s_and_p(im, 0.5, 0.1)
    test_snp_01[i] = serialize(snp_01)

    gauss_5_snp_005 = noise.s_and_p(im, 0.5, 0.05)
    gauss_5_snp_005 = noise.gauss(gauss_5_snp_005, 5)
    test_5_005[i] = serialize(gauss_5_snp_005)

    gauss_10_snp_002 = noise.s_and_p(im, 0.5, 0.02)
    gauss_10_snp_002 = noise.gauss(gauss_10_snp_002, 10)
    test_10_002[i] = serialize(gauss_10_snp_002)

    gauss_15_snp_01 = noise.s_and_p(im, 0.5, 0.1)
    gauss_15_snp_01 = noise.gauss(gauss_15_snp_01, 15)
    test_15_01[i] = serialize(gauss_15_snp_01)

    rnd_gauss = random.randint(5, 25)
    rnd_snp = random.uniform(0.05, 0.1)
    rand = noise.s_and_p(im, 0.5, rnd_snp)
    rand = noise.gauss(rand, rnd_gauss)
    test_random[i] = serialize(rand)

filesave.as_text(test_clean, 'data/clean/test/file.my-obj')
filesave.as_text(test_gauss_5, 'data/noisy/test/gauss_5.my-obj')
filesave.as_text(test_gauss_10, 'data/noisy/test/gauss_10.my-obj')
filesave.as_text(test_gauss_15, 'data/noisy/test/gauss_15.my-obj')
filesave.as_text(test_snp_002, 'data/noisy/test/snp_002.my-obj')
filesave.as_text(test_snp_005, 'data/noisy/test/snp_005.my-obj')
filesave.as_text(test_snp_01, 'data/noisy/test/snp_01.my-obj')
filesave.as_text(test_5_005, 'data/noisy/test/gauss_5_snp_005.my-obj')
filesave.as_text(test_10_002, 'data/noisy/test/gauss_10_snp_002.my-obj')
filesave.as_text(test_15_01, 'data/noisy/test/gauss_15_snp_01.my-obj')
filesave.as_text(test_random, 'data/noisy/test/random.my-obj')

imgs_train, labels_train = mnist.load_training()

train_clean = np.empty(imgs_train.__len__(), dtype=object)
train_gauss_5 = np.empty(imgs_train.__len__(), dtype=object)
train_gauss_10 = np.empty(imgs_train.__len__(), dtype=object)
train_gauss_15 = np.empty(imgs_train.__len__(), dtype=object)
train_snp_002 = np.empty(imgs_train.__len__(), dtype=object)
train_snp_005 = np.empty(imgs_train.__len__(), dtype=object)
train_snp_01 = np.empty(imgs_train.__len__(), dtype=object)
train_5_005 = np.empty(imgs_train.__len__(), dtype=object)
train_10_002 = np.empty(imgs_train.__len__(), dtype=object)
train_15_01 = np.empty(imgs_train.__len__(), dtype=object)
train_random = np.empty(imgs_train.__len__(), dtype=object)

for i in xrange(imgs_train.__len__()):
    im_arr = imgs_train[i]
    img = [[0]*28 for x in xrange(28)]
    for j in range(784):
        x = int(j / 28)
        y = j % 28
        img[x][y] = im_arr[j]
    im = np.asarray(img)
    train_clean[i] = im_arr

    gauss_5 = noise.gauss(im, 5)
    train_gauss_5[i] = serialize(gauss_5)
    gauss_10 = noise.gauss(im, 10)
    train_gauss_10[i] = serialize(gauss_10)
    gauss_15 = noise.gauss(im, 15)
    train_gauss_15[i] = serialize(gauss_15)
    snp_002 = noise.s_and_p(im, 0.5, 0.02)
    train_snp_002[i] = serialize(snp_002)
    snp_005 = noise.s_and_p(im, 0.5, 0.05)
    train_snp_005[i] = serialize(snp_005)
    snp_01 = noise.s_and_p(im, 0.5, 0.1)
    train_snp_01[i] = serialize(snp_01)

    gauss_5_snp_005 = noise.s_and_p(im, 0.5, 0.05)
    gauss_5_snp_005 = noise.gauss(gauss_5_snp_005, 5)
    train_5_005[i] = serialize(gauss_5_snp_005)

    gauss_10_snp_002 = noise.s_and_p(im, 0.5, 0.02)
    gauss_10_snp_002 = noise.gauss(gauss_10_snp_002, 10)
    train_10_002[i] = serialize(gauss_10_snp_002)

    gauss_15_snp_01 = noise.s_and_p(im, 0.5, 0.1)
    gauss_15_snp_01 = noise.gauss(gauss_15_snp_01, 15)
    train_15_01[i] = serialize(gauss_15_snp_01)

    rnd_gauss = random.randint(5, 25)
    rnd_snp = random.uniform(0.05, 0.1)
    rand = noise.s_and_p(im, 0.5, rnd_snp)
    rand = noise.gauss(rand, rnd_gauss)
    train_random[i] = serialize(rand)

filesave.as_text(train_clean, 'data/clean/train/file.my-obj')
filesave.as_text(train_gauss_5, 'data/noisy/train/gauss_5.my-obj')
filesave.as_text(train_gauss_10, 'data/noisy/train/gauss_10.my-obj')
filesave.as_text(train_gauss_15, 'data/noisy/train/gauss_15.my-obj')
filesave.as_text(train_snp_002, 'data/noisy/train/snp_002.my-obj')
filesave.as_text(train_snp_005, 'data/noisy/train/snp_005.my-obj')
filesave.as_text(train_snp_01, 'data/noisy/train/snp_01.my-obj')
filesave.as_text(train_5_005, 'data/noisy/train/gauss_5_snp_005.my-obj')
filesave.as_text(train_10_002, 'data/noisy/train/gauss_10_snp_002.my-obj')
filesave.as_text(train_15_01, 'data/noisy/train/gauss_15_snp_01.my-obj')
filesave.as_text(train_random, 'data/noisy/train/random.my-obj')



"""
    gauss_5 = noise.gauss(im, 5)
    cv2.imwrite(('data/noisy/test/gauss_5/'+'img_'+str(i)+'.png'), gauss_5)
    gauss_10 = noise.gauss(im, 10)
    cv2.imwrite(('data/noisy/test/gauss_10/'+'img_'+str(i)+'.png'), gauss_10)
    gauss_15 = noise.gauss(im, 15)
    cv2.imwrite(('data/noisy/test/gauss_15/'+'img_'+str(i)+'.png'), gauss_15)
    snp_002 = noise.s_and_p(im, 0.5, 0.02)
    cv2.imwrite(('data/noisy/test/s&p_002/'+'img_'+str(i)+'.png'), snp_002)
    snp_005 = noise.s_and_p(im, 0.5, 0.05)
    cv2.imwrite(('data/noisy/test/s&p_005/'+'img_'+str(i)+'.png'), snp_005)
    snp_01 = noise.s_and_p(im, 0.5, 0.1)
    cv2.imwrite(('data/noisy/test/s&p_01/'+'img_'+str(i)+'.png'), snp_01)
    gauss_5_snp_005 = noise.s_and_p(im, 0.5, 0.05)
    gauss_5_snp_005 = noise.gauss(gauss_5_snp_005, 5)
    cv2.imwrite(('data/noisy/test/gauss_5+s&p_005/'+'img_'+str(i)+'.png'), gauss_5_snp_005)
    gauss_10_snp_002 = noise.s_and_p(im, 0.5, 0.02)
    gauss_10_snp_002 = noise.gauss(gauss_10_snp_002, 10)
    cv2.imwrite(('data/noisy/test/gauss_10+s&p_002/'+'img_'+str(i)+'.png'), gauss_10_snp_002)
    gauss_15_snp_01 = noise.s_and_p(im, 0.5, 0.1)
    gauss_15_snp_01 = noise.gauss(gauss_15_snp_01, 15)
    cv2.imwrite(('data/noisy/test/gauss_15+s&p_01/'+'img_'+str(i)+'.png'), gauss_15_snp_01)

imgs_train, labels_train = mnist.load_training()

for i in xrange(imgs_train.__len__()):
    im_arr = imgs_train[i]
    img = [[0]*28 for x in xrange(28)]
    for j in range(784):
        x = int(j / 28)
        y = j % 28
        img[x][y] = im_arr[j]
    im = np.asarray(img)
    cv2.imwrite(('data/clean/train/'+'img_'+str(i)+'.png'), im)

    gauss_5 = noise.gauss(im, 5)
    cv2.imwrite(('data/noisy/train/gauss_5/'+'img_'+str(i)+'.png'), gauss_5)
    gauss_10 = noise.gauss(im, 10)
    cv2.imwrite(('data/noisy/train/gauss_10/'+'img_'+str(i)+'.png'), gauss_10)
    gauss_15 = noise.gauss(im, 15)
    cv2.imwrite(('data/noisy/train/gauss_15/'+'img_'+str(i)+'.png'), gauss_15)
    snp_002 = noise.s_and_p(im, 0.5, 0.02)
    cv2.imwrite(('data/noisy/train/s&p_002/'+'img_'+str(i)+'.png'), snp_002)
    snp_005 = noise.s_and_p(im, 0.5, 0.05)
    cv2.imwrite(('data/noisy/train/s&p_005/'+'img_'+str(i)+'.png'), snp_005)
    snp_01 = noise.s_and_p(im, 0.5, 0.1)
    cv2.imwrite(('data/noisy/train/s&p_01/'+'img_'+str(i)+'.png'), snp_01)
    gauss_5_snp_005 = noise.s_and_p(im, 0.5, 0.05)
    gauss_5_snp_005 = noise.gauss(gauss_5_snp_005, 5)
    cv2.imwrite(('data/noisy/train/gauss_5+s&p_005/'+'img_'+str(i)+'.png'), gauss_5_snp_005)
    gauss_10_snp_002 = noise.s_and_p(im, 0.5, 0.02)
    gauss_10_snp_002 = noise.gauss(gauss_10_snp_002, 10)
    cv2.imwrite(('data/noisy/train/gauss_10+s&p_002/'+'img_'+str(i)+'.png'), gauss_10_snp_002)
    gauss_15_snp_01 = noise.s_and_p(im, 0.5, 0.1)
    gauss_15_snp_01 = noise.gauss(gauss_15_snp_01, 15)
    cv2.imwrite(('data/noisy/train/gauss_15+s&p_01/'+'img_'+str(i)+'.png'), gauss_15_snp_01)


#for i in xrange(imgs_train.__len__()):
im_array = imgs_train[0]
img = [[0]*28 for x in xrange(28)]
for j in range(784):
    x = int(j / 28)
    y = j % 28
    img[x][y] = im_array[j]
im = np.asarray(img)
#noisy = noise.gauss(im, 15)
noisy = noise.poisson(im)
#noisy = noise.s_and_p(im, 0.5, 0.05)
#noisy = noise.noisy("s&p", im)

#plt.imshow(noisy)
#plt.savefig('img.png')
#mpimg.imsave('out.png', noisy)
#cv2.imwrite('data/noisy/train/poisson/out.png', noisy)
#plt.imshow(noisy)

"""
