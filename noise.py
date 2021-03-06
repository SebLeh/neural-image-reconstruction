__author__ = 'Sebi'

import numpy as np

class noise():

    def gauss(self, image, factor):
            row, col = image.shape
            mean = 0
            gauss = np.random.normal(mean, factor, (row, col))
            gauss = gauss.reshape(row, col)
            noisy = image + gauss
            return noisy

    def s_and_p(self, image, factor=0.5, amount=0.004):
            row, col = image.shape
            s_vs_p = factor
            amount = amount
            out = image
            # Salt mode
            num_salt = np.ceil(amount * image.size * s_vs_p)
            coords = [np.random.randint(0, i - 1, int(num_salt))
                      for i in image.shape]
            out[coords] = 255

            # Pepper mode
            num_pepper = np.ceil(amount* image.size * (1. - s_vs_p))
            coords = [np.random.randint(0, i - 1, int(num_pepper))
                      for i in image.shape]
            out[coords] = 0
            return out

    def poisson(self, image):
            vals = len(np.unique(image))
            vals = 2 ** np.ceil(np.log2(vals))
            noisy = np.random.poisson(image * vals) / float(vals)
            return noisy

    def speckle(self, image):
            row, col = image.shape
            gauss = np.random.randn(row, col)
            gauss = gauss.reshape(row, col)
            noisy = image + image * gauss
            return noisy

    def noisy(self, noise_typ, image):
        if noise_typ == "gauss":
            row, col = image.shape
            mean = 0
            #var = 0.1
           #sigma = var**0.5
            gauss = np.random.normal(mean, 5, (row, col))
            gauss = gauss.reshape(row, col)
            noisy = image + gauss
            return noisy
        elif noise_typ == "s&p":
            row, col = image.shape
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