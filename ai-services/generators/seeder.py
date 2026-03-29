from api.services.subject_service import SubjectService
from api.schemas.subject import SubjectCreateDTO
from generators.generator import Func, Generator
from generators.values import subject
from itertools import product
from random import shuffle
from uuid import UUID

class Seeder:
    @staticmethod
    def subjects(user_id: UUID | str, count: int, batch_size: int = 100) -> None:
        """ Seeds 'n' subjects to the database via API """
        try:
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

                dto: SubjectCreateDTO = SubjectCreateDTO(
                    creatorUserId=user_id,
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

            print(f"\nSuccessfully inserted all '{count}' subjects")
        except Exception as e:
            print(f"\n{e}")
