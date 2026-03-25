from api.schemas.common.base import BaseDTO, BaseAuditableDTO
from api.schemas.common.filter import BaseFilterDTO


# User - To get the response
class UserResponseDTO(BaseAuditableDTO):
    profilePic: list | None
    username: str
    email: str

# User - To create
class UserCreateDTO:
    profilePic: list | None = None
    username: str
    email: str
    password: str

# User - To filter
class UserFilterDTO(BaseFilterDTO):
    email: str | None = None

# User - To update/patch
class UserUpdateDTOs:
    class UpdateProfilePic(BaseDTO):
        profilePic: list | None

    class UpdateUsername(BaseDTO):
        username: str

    class UpdatePassword(BaseDTO):
        oldPassword: str
        newPassword: str
        confirmPassword: str
