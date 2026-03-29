from generators.seeder import Seeder

if __name__ == '__main__':
    try:
        count: int = 26928
        Seeder.subjects('AE19B944-4B9C-4338-86D4-1A70016B701F', count)

    except Exception as e:
        print("\nError:", f"{e}", sep='\n')

"""
import argparse as ap

parser = ap.ArgumentParser()

# * Adding CLI arguments
parser.add_argument('msg', help='The message you want to print.')
parser.add_argument('-n', '--name', help='The name you want to print with the message.', default=None)
parser.add_argument('-t', '--times', help='Number of times you want to print.', default=1, type=int)

# * Parse the arguments
args = parser.parse_args()

# * Use them
for count in range(args.times):
    if args.name is None:
        print(args.msg)
    else:
        print(args.msg, args.name)
"""
