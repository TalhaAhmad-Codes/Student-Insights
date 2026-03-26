class AutoMapper:
    @staticmethod
    def to_dto(dto, res, to_list: bool = False):
        try:
            # return dto(**res) if not to_list else PagedResponse[dto](**res)
            return dto(**res) if not to_list else [dto(**x) for x in res['items']]
        except Exception as e:
            print("You gave wrong parameters...", f"{e}", sep='\n')
