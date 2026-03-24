import argparse


def create_parser():
    parser = argparse.ArgumentParser(
        prog="seeder",
        description="Student Insight Data Seeder CLI"
    )

    subparsers = parser.add_subparsers(dest="command", required=True)

    # -----------------------------
    # students command
    # -----------------------------
    students_parser = subparsers.add_parser("students")

    students_parser.add_argument("count", type=int)

    students_parser.add_argument("--department", action="store_true")
    students_parser.add_argument("--all", action="store_true")
    students_parser.add_argument("--every", action="store_true")

    # -----------------------------
    # random command
    # -----------------------------
    random_parser = subparsers.add_parser("random")

    random_parser.add_argument("--students", type=int, required=True)
    random_parser.add_argument("--departments", type=int, required=True)
    random_parser.add_argument("--exams", type=int, required=True)

    random_parser.add_argument("--all", action="store_true")
    random_parser.add_argument("--every", action="store_true")

    return parser
