        protected void Notify([CallerMemberName] string propertyName = "")
        {
            this.NotifyCustom(propertyName);
        }

        protected void NotifyCustom(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }