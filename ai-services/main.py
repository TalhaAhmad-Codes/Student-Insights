from misc.unique_generator import Unique
from random import randint, shuffle

count: int = 50
data: list = [i for i in range(count)]
shuffle(data)
data.extend([randint(0, count - 1) for _ in range(randint(count // 5, count))])

print("Original:", data, sep='\t')
unique = Unique(count)

print("Unique:", not Unique.contains_duplicate(data), sep='\t\t')

unique.generate(data)
data = unique.data
print("New:", data, sep='\t\t')
print("Unique:", not Unique.contains_duplicate(data), sep='\t\t')

# from generators.seeder import Seeder
#
# if __name__ == '__main__':
#     try:
#         count: int = 100
#         Seeder.users(
#             password='12345678',
#             count=count
#         )
#
#     except Exception as e:
#         print("\n\nMake sure your backend service is running..!")
#
# """
# import argparse as ap
#
# parser = ap.ArgumentParser()
#
# # * Adding CLI arguments
# parser.add_argument('msg', help='The message you want to print.')
# parser.add_argument('-n', '--name', help='The name you want to print with the message.', default=None)
# parser.add_argument('-t', '--times', help='Number of times you want to print.', default=1, type=int)
#
# # * Parse the arguments
# args = parser.parse_args()
#
# # * Use them
# for count in range(args.times):
#     if args.name is None:
#         print(args.msg)
#     else:
#         print(args.msg, args.name)
# """
#
