print("MAIN FILE STARTED")

from cli.parser import create_parser
from cli.commands.students import run_students
from cli.commands.random import run_random


def main():
    parser = create_parser()
    args = parser.parse_args()

    print("Command received:", args.command)

    if args.command == "students":
        run_students(args)

    elif args.command == "random":
        run_random(args)

if __name__ == '__main__':
    main()

"""
? python -m cli.main students 200 --all
* ../ai-services
"""
