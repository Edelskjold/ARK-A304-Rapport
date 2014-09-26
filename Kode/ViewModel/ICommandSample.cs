        public ICommand AddBlank
        {
            get
            {
                return new RelayCommand(
                    x =>
                        {
                            if (this.SelectedMembers.Count < this.SelectedBoat.NumberofSeats)
                            {
                                this.SelectedMembers.Add(
                                    new MemberViewModel(new Member() { Id = -1, FirstName = "Blank" }));
                            }
                        });
            }
        }