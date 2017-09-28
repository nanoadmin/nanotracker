import os
import time 


print('waiting 10 seconds in hope that device will connect to internet ')

time.sleep(10)

print('get latest version of source for devices_will_pull_this branch')

os.system('git pull origin devices_will_pull_this')

os.system('python3 main.py')
