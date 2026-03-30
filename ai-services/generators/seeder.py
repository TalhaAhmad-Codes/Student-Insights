from api.services.subject_service import SubjectService
from api.services.user_service import UserService
from api.schemas.subject import SubjectCreateDTO
from api.schemas.user import UserCreateDTO
from generators.generator import Func, Generator
from generators.values import subject
from itertools import product
from random import shuffle
from uuid import UUID

class Seeder:
    @staticmethod
    def subjects(**kwargs) -> None:
        """ Seeds 'n' subjects to the database via API """
        try:
            user_id: UUID | str = kwargs.get('user_id')
            count: int = kwargs.get('count')
            batch_size = kwargs.get('batch_size', count // 5)

            length_limit: int = 70
            limit: int = Func.unique_subjects_limit()
            subjects: list[SubjectCreateDTO] = []

            if count > limit:
                raise Exception(f"You can't exceed the limit '{limit}' with unique constraint.")

            # Generating unique subjects
            print(f"Generating {count} unique subjects...")
            combinations: list[str] = [
                f"{p} {c} {s}"
                for p, c, s in product(subject['prefix'], subject['core'], subject['suffix'])
            ]
            shuffle(combinations)

            # Creating DTOs
            for _subject in combinations[:count]:
                if len(_subject) > length_limit:
                    print(f"The subject '{_subject}' length is greate than the limit '{length_limit}'.")

                dto: SubjectCreateDTO = Generator.subject(
                    user_id=user_id,
                    name=_subject
                )

                subjects.append(dto)

            # Seeding DTOs as Bulk
            print(f"\nSeeding {int(len(subjects) / batch_size)} batches...")
            for i in range(0, len(subjects), batch_size):
                print(f"Batch #{i + 1}", end='')
                batch = subjects[i:i + batch_size]
                SubjectService.create_bulk(batch)
                print(" --- Successful!")

            print(f"\nSuccessfully inserted all '{count}' subjects!")
        except Exception as e:
            print(f"\n{e}")

    @staticmethod
    def users(**kwargs) -> None:
        password: str | None = kwargs.get('password', None)
        domain: str = kwargs.get('domain', 'gmail.com')
        count: int = kwargs.get('count')
        batch_size: int = kwargs.get('batch_size', count // 5)

        # Generating DTOs
        print(f"Generating {count} unique users...")
        users: list[UserCreateDTO] = [
            Generator.user(
                domain=domain,
                password=password
            ) for _ in range(count)
        ]

        # Seeding DTOs
        print(f"\nSeeding {int(len(users) / batch_size)} batches...")
        for i in range(0, len(users), batch_size):
            print(f"Batch #{i + 1}", end='')
            batch = users[i:i + batch_size]
            UserService.create_bulk(batch)
            print(" --- Successful!")

        print(f"\nSuccessfully inserted all '{count}' users!")
