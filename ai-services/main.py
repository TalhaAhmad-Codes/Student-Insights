from api.services.student_service import StudentService
from api.services.user_service import UserService
from rich import print as display

if __name__ == '__main__':
    try:
        result = UserService.get_all()
        display(result)
    except Exception as e:
        print("Check your network connection / server.", f"Details:\n{e}", sep='\n\n')

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
