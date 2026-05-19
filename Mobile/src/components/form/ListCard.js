import { View, Text } from 'react-native';
import { formStyles as s } from './formStyles';

export default function ListCard({ title, children, style }) {
  return (
    <View style={[s.listCard, style]}>
      {title ? <Text style={s.listCardTitle}>{title}</Text> : null}
      {children}
    </View>
  );
}

export function ListCardText({ children, style }) {
  return <Text style={[s.listCardText, style]}>{children}</Text>;
}
